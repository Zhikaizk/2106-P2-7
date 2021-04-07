namespace Project.Models
{
    public interface IDecryption : ISecurity
    {
        public string decryptionPerformed(string password);      
    }
}

