using System.Collections.Generic;

public class Customers
{
    public string custID;
    public string custName;

    public Customers()
    {
    }

    public Customers(List<string> custInf)
    {
        custID = custInf[0];
        custName = custInf[1];
    }
}

public class Flights
{
    public string flightNum;
    public string price;
    public string numSeats;
    public string numAvail;
    public string takeOffTime;
    public string landOnTime;
    public string fromCity;
    public string arivCity;

    public string FlightNumText;
    public string TimeText;
    public string CityText;
    public string SeatsText;
    public string PriceText;

    public Flights() { }

    public Flights(List<string> flight)
    {
        flightNum = flight[0];
        price = flight[1];
        numSeats = flight[2];
        numAvail = flight[3];
        takeOffTime = flight[4];
        landOnTime = flight[5];
        fromCity = flight[6];
        arivCity = flight[7];

        FlightNumText = flightNum;
        TimeText = takeOffTime + " - " + landOnTime;
        CityText = fromCity + " - " + arivCity;
        PriceText = "￥" + price + ".00";
        SeatsText = numAvail + "/" + numSeats;
    }
}

public class Hotels
{
    public string location;
    public string name;
    public string starLevel;
    public string price;
    public string numRooms;
    public string numAvail;

    public string LocationText;
    public string NameText;
    public string StarLevelText;
    public string PriceText;
    public string RoomsText;

    public Hotels() { }
    public Hotels(List<string> hotel)
    {
        location = hotel[0];
        name = hotel[1];
        starLevel = hotel[2];
        price = hotel[3];
        numRooms = hotel[4];
        numAvail = hotel[5];

        LocationText = location;
        NameText = name;
        StarLevelText = starLevel;
        PriceText = "￥" + price;
        RoomsText = numAvail + "/" + numRooms;
    }
}

public class Buses
{
    public string location;
    public string name;
    public string price;
    public string numBus;
    public string numAvail;

    public string LocationText;
    public string NameText;
    public string PriceText;
    public string SeatsText;

    public Buses() { }
    public Buses(List<string> bus)
    {
        location = bus[0];
        name = bus[1];
        price = bus[2];
        numBus = bus[3];
        numAvail = bus[4];

        LocationText = location;
        NameText = name;
        PriceText = "￥" + price + ".00";
        SeatsText = numAvail + "/" + numBus;
    }
}

public class Tracks
{
    public string flightNum;
    public string price;
    public string takeOffTime;
    public string landOnTime;
    public string fromCity;
    public string arivCity;

    public string FlightNumText;
    public string TimeText;
    public string CityText;
    public string PriceText;

    public Tracks() { }

    public Tracks(List<string> track)
    {
        flightNum = track[0];
        price = track[1];
        takeOffTime = track[2];
        landOnTime = track[3];
        fromCity = track[4];
        arivCity = track[5];

        FlightNumText = flightNum;
        TimeText = takeOffTime + " - " + landOnTime;
        CityText = fromCity + " - " + arivCity;
        PriceText = "￥" + price + ".00";
    }
}

public class Resvs
{
    public string custName;
    public string resvType;
    public string resvName;
    public string resvKey;

    public string CustNameText;
    public string ResvTypeText;
    public string ResvNameText;
    public string ResvKeyText;

    public Resvs() { }
    public Resvs(List<string> resv)
    {
        custName = resv[0];
        resvType = resv[1];
        resvName = resv[2];
        resvKey = resv[3];

        CustNameText = custName;
        ResvNameText = resvName;
        ResvKeyText = resvKey;
        switch (resvType)
        {
            case "1":
                ResvTypeText = "航班";
                break;
            case "2":
                ResvTypeText = "宾馆";
                break;
            case "3":
                ResvTypeText = "巴士";
                break;
            default:
                break;
        }
    }
}