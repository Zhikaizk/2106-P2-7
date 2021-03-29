namespace Project.Models
{
    public interface IEncryption : ISecurity
    {
        public string encryptionPerformed(string password);      
    }
}

