
public class TradeProcessor {
    public TradeProcessor(ITradeDataProvider tradeDataProvider, ITradeParser tradeParser, ITradeStorage tradeStorage){
        this.tradeDataProvider = tradeDataProvider;
        this.tradeParser       = tradeParser;
        this.tradeStorage      = tradeStorage;
    }

    public void ProcessTrades() {
        var lines  = tradeDataProvider.GetTradeData();
        var trades = tradeParser.Parse(lines);
        tradeStorage.Persist(trades);
    }

    private readonly ITradeDataProvider tradeDataProvider;
    private readonly ITradeParser tradeParser;
    private readonly ITradeStorage tradeStorage;
}

public class StreamTradeDataProvider : ITradeDataProvider{
    public StreamTradeDataProvider(Stream stream) {
        this.stream = stream;
    }

    public IEnumerable<string> GetTradeData(){
        var tradeData = new List<string>();
        using (var reader = new StreamReader(stream)){
            string line;
            while ((line = reader.ReadLine()) != null){
                tradeData.Add(line);
            }
        }
        return tradeData;
    }
    private Stream stream;
}

public class SimpleTradeParser : ITradeParser {

    public SimpleTradeParser(ITradeValidator tradeValidator, ITradeMapper tradeMapper){
        this.tradeValidator = tradeValidator;
        this.tradeMapper    = tradeMapper;
    }

    public IEnumerable<TradeRecord> Parse(IEnumerable<string> tradeData){
        var trades = new List<TradeRecord>();
        var lineCount = 1;
        foreach(var line in tradeData) {
            var fields = line.Split(new char[] { ',' });
            if (!tradeValidator.Validate(fields)) {
                continue;
            }
            var trade = tradeMapper.Map(fields);
            trades.Add(trade);
            lineCount++;
        }
        return trades;
    }
    private readonly ITradeValidator tradeValidator;
    private readonly ITradeMapper tradeMapper;

interface ILogger {
    void LogWarning(string message);
}

class SimpleLogger : ILogger {
    public void LogWarning(string message) => Console.WriteLine(message);
}

public class SimpleTradeValidator : ITradeValidator {
    private readonly ILogger logger; 
    
    public SimpleTradeValidator(ILogger logger) {
        this.logger = logger;
    }

    public bool Validate(string[] tradeData) {
        if (tradeData.Length != 3) {
            logger.LogWarning("Line malformed. Only {1} field(s) found.", tradeData.Length);
            return false;
        }
        if (tradeData[0].Length != 6){
            logger.LogWarning("Trade currencies malformed: '{1}'", tradeData[0]);
            return false;
        }
        int tradeAmount;
        if (!int.TryParse(tradeData[1], out tradeAmount)){
            logger.LogWarning("Trade amount not a valid integer: '{1}'", tradeData[1]);
            return false;
        }
        decimal tradePrice;
        if (!decimal.TryParse(tradeData[2], out tradePrice)){
            logger.LogWarning("WARN: Trade price not a valid decimal: '{1}'", tradeData[2]);
            return false;
        }
        return true;
    }
}

class StoreNull : ITradeStorage {
    public int Contador;
    void Persist(IEnumerable<TradeRecord> registros){
        Contador++;
    }
}

class ProvidePrueba: ITradeProvider {
    public IEnumerable<string> GetTradeData(){
        return new string[]{"DOLPES,100,234", "DOLPES,200,150"};
}

void Main(){

    Stream s = new();
    System.Data.SqlClient.SqlConnection coneccion = new();

//    ITradeDataProvider provider = new ITradeDataProvider(s);   
    
    ITradeDataProvider provider = new ProvidePrueba();   
    ITradeParser parse = new tradeParser();
    StoreNull store = new StoreNull();

    TradeProcessor t = new TradeProcessor(provider, parse, store);
    t.ProcessTrades();
    Console.WriteLine($"Se grabaron {store.contador}");   
}