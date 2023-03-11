using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task5_CRUD.Domain;

namespace Task5_CRUD.Infrastructure.DbContexts;

public static class MapPointConverter
{
    public static string convertMapPointToString(MapPoint mapPoint)
    {
        return $"{mapPoint.X},{mapPoint.Y},{mapPoint.Z}";
    }

    public static MapPoint convertStringToMapPoint(string mapPointString)
    {
        var mapPointArray = mapPointString.Split(',');
        return new MapPoint() {
            X = Convert.ToInt32(mapPointArray[0]),
            Y = Convert.ToInt32(mapPointArray[1]),
            Z = Convert.ToInt32(mapPointArray[2])
        };
    }
}