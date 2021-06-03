using System.Threading.Tasks;

namespace RSoft.Framework.Infra.Data.MongoDb.Creators
{


    /// <summary>
    /// Database creator interface contract
    /// </summary>
    public interface IDatabaseCreator
    {

        /// <summary>
        /// Perform database creation
        /// </summary>
        Task CreateDatabase();

    }
}
