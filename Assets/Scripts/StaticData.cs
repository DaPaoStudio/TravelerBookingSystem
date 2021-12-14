using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class StaticData
{
    public static bool isError = false;
    public static string flightsInit = "insert into flights values"
        + "('CZ8226', 600, 120, 120, '15:30', '17:50', '西安', '南宁'),"
        + "('MU2283', 240, 120, 120, '22:50', '00:40+1', '西安', '长沙'),"
        + "('MU2196', 400, 120, 120, '07:00', '09:20', '西安', '上海'),"
        + "('CZ3262', 570, 120, 120, '14:25', '16:30', '上海', '南宁'),"
        + "('MF3170', 900, 120, 120, '15:00', '17:10', '上海', '长沙'),"
        + "('GX8970', 520, 80, 80, '13:15', '14:30', '长沙', '南宁'),"
        + "('GX8915', 260, 120, 120, '09:50', '11:20', '长沙', '广州');";

    public static string hotelInit = "insert into hotels values"
        + "('西安','西电看守所','☆☆☆☆☆',328,20,20),"
        + "('南宁','南宁大饭店','★★★★★',520,120,120),"
        + "('上海','上海开瓶器假日酒店','☆★★★☆',208,60,60),"
        + "('长沙','长沙五一大酒店','☆★★★☆',618,150,150),"
        + "('广州','广州流水灯假日酒店','☆★★★☆',420,90,90);";

    public static string busInit = "insert into bus values"
        + "('西安','西安城墙代步车',20,60,60),"
        + "('南宁','南宁青秀山旅游专车',55,80,80),"
        + "('上海','上海观光巴士',15,40,40),"
        + "('长沙','长沙观光巴士',60,90,90),"
        + "('广州','广州观光巴士',35,60,60);";
}
