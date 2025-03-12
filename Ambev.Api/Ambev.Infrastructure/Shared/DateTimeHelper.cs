namespace Ambev.Infrastructure.Shared;

public static class DateTimeHelper
{
    public static DateTime GetSqlServerSafeDateTime(DateTime dateTime)
    {
        // O SQL Server aceita datas a partir de 01/01/1753
        DateTime minSqlServerDate = new DateTime(1753, 1, 1);

        // Se a data fornecida for menor que a mínima permitida, retorna a mínima permitida
        if (dateTime < minSqlServerDate)
        {
            return minSqlServerDate;
        }

        // Arredonda a precisão para milissegundos (truncando os ticks extras)
        return new DateTime(dateTime.Ticks / 10_000 * 10_000, dateTime.Kind);
    }
}
