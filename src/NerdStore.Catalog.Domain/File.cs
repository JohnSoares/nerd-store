using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalog.Domain
{
    public class File : Entity
    {
        public string FileName { get; private set; }

        public byte[] DataFiles { get; private set; }

        public File(string fileName, byte[] dataFiles)
        {
            FileName = fileName;
            DataFiles = dataFiles;

            Validate();
        }

        public void Validate()
        {
            AssertConcern.ValidateIfEmpty(FileName, "O campo Nome do arquivo não pode estar vazio");
            AssertConcern.ValidateIfNull(DataFiles, "O campo Dados do arquivo não pode estar vazio");
        }
    }
}
