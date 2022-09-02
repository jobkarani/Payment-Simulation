
    $(document).ready(function () {
        $('#transactionDatatable').DataTable(
            {
                ajax: {
                    url: "Transactions/GetTransactions",
                    type: "POST",
                },
                processing: true,
                serverSide: true,
                filter: true,
                columns: [
                    { data: "Id", name: "Id" },
                    { data: "Remitter.name", name: "Remitter.name" },
                    { data: "Remitter.primaryAccountNumber", name: "Remitter.primaryAccountNumber" },
                    { data: "Recipient.name", name: "Recipient.name" },
                    { data: "Recipient.primaryAccountNumber", name: "Recipient.primaryAccountNumber" },
                    { data: "channelType", name: "channelType" },
                    { data: "amount", name: "amount" },
                    { data: "reference", name: "reference" },
                ]
            }
        );
       });