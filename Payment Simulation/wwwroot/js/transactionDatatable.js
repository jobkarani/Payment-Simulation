
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
                    { data: "transactionStatusDescription", name: "transactionStatusDescription" },
                    { data: "amount", name: "amount" },
                    { data: "feeAmount", name: "feeAmount" },
                    { data: "resultCodeDescription", name: "resultCodeDescription" },
                    { data: "customerAccountNo", name: "customerAccountNo" },
                    { data: "reference", name: "reference" },
                ]
            }
        );
       });