using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

namespace WcfServiceLibrary1
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        DataSet AllClients();      

        [OperationContract]
        DataSet GetClient(int idClient);

        [OperationContract]
        string InsClient(string fio);

        [OperationContract]
        string DelClient(int idClient);

        [OperationContract]
        string UpdClient(int idClient, string fio);


        [OperationContract]
        DataSet AllZayavky();
        
        [OperationContract]
        DataSet GetZayavka(int idZayavka);

        [OperationContract]
        string InsZayavka(int idZayavka);

        [OperationContract]
        string DelZayavka(int idZayavka);

        [OperationContract]
        string UpdZayavka(int idZayavka, int clientId);


        [OperationContract]
        DataSet AllUsluga();

        [OperationContract]
        DataSet GetUsluga(int idUsluga);

        [OperationContract]
        string InsUsluga(string nazvanie, int cena);

        [OperationContract]
        string DelUsluga(int idUsluga);

        [OperationContract]
        string UpdUsluga(int idUsluga, int cena);


        [OperationContract]
        DataSet AllZayavkyUslugy();

        [OperationContract]
        DataSet GetZayavkaUsluga(int id);

        [OperationContract]
        string InsZayavkaUsluga(int zayavkaId, int uslugaId);

        // TODO: Добавьте здесь операции служб
    }

    // Используйте контракт данных, как показано на следующем примере, чтобы добавить сложные типы к сервисным операциям.
    // В проект можно добавлять XSD-файлы. После построения проекта вы можете напрямую использовать в нем определенные типы данных с пространством имен "WcfServiceLibrary1.ContractType".
   
}
