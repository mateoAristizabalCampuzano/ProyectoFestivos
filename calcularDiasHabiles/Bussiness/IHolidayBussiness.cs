using calcularDiasHabiles.Entities;

namespace calcularDiasHabiles.Bussiness
{
    public interface IHolidayBussiness
    {
        Task<HolidaysEntities> CalcularApiFestivos();
    }
}
