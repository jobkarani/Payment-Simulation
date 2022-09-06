
    $(document).ready(function () {
        $('#transactionDatatable').DataTable(
            {
                ajax: {
                    url: "/Transactions/GetTransactions",
                    type: "POST",
                },
                processing: true,
                serverSide: true,
                filter: true,
                columns: [
                    { data: "id", name: "Id" },
                    { data: "remitter.name", name: "Remitter.name" },
                    { data: "remitter.primaryAccountNumber", name: "Remitter.primaryAccountNumber" },
                    { data: "recipient.name", name: "Recipient.name" },
                    { data: "recipient.primaryAccountNumber", name: "Recipient.primaryAccountNumber" },
                    { data: "channelType", name: "channelType" },
                    { data: "amount", name: "amount" },
                    { data: "reference", name: "reference" },
                ]
            }
        );
       });