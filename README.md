# CowenStockAPI

Simple API with stock prices created by Kai Mihata. The web api uses an in memory database that loads from a simple (100 entries) json file containing some simple stock information. The data hasn't been cleaned up much so there are a few duplicate entries. 


## Schema

    public class StockTicker {
        public long Id { get; set; }
        
        public string Symbol { get; set; }
        
        public float Open { get; set; }
        
        public float High { get; set; }
        
        public float Low { get; set; }
        
        public float Close { get; set; }
        
        public float Volume { get; set; }
    }


## Methods

Get all Data: `GET /api/CowenAPI`

Get data by id: `GET /api/CowenAPI/{id}`

Get data for a specific Symbol (Case insensitive): `GET /api/CowenAPI/symbol/{symbol}`

Get all data with price greater than: `GET /api/CowenAPI/price/close/greater/{price}`

Get all data with price less than: `GET /api/CowenAPI/price/close/less/{price}`

Get all data with volume greater than: `GET /api/CowenAPI/price/volume/greater/{volume}`

Get all data with volume less than: `GET /api/CowenAPI/price/volume/less/{volume}`

Upload new stock data: `POST /api/CowenAPI`

Upload an array of new stock data (Takes array of StockTickers): `POST /api/CowenAPI/PostStockTicker`

Delete an entry with id: `DELETE /api/CowenAPI/{id}`
