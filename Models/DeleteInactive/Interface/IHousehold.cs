namespace Project.Models.DeleteInactive
{
    public interface IHousehold
    {
        string email { get; set; }
        string eplan { get; set; }
        int hlocation { get; set; }
        int property_size { get; set; }
        string roomlist { get; set; }
        string username { get; set; }
    }
}