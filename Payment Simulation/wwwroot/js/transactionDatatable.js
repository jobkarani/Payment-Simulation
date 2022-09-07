
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
                    { data: "remitter.name", name: "Remitter.name" },
                    { data: "remitter.primaryAccountNumber", name: "Remitter.primaryAccountNumber" },
                    { data: "remitter.phoneNumber", name: "Remitter.phoneNumber" },
                    { data: "recipient.name", name: "Recipient.name" },
                    { data: "recipient.primaryAccountNumber", name: "Recipient.primaryAccountNumber" },
                    { data: "recipient.phoneNumber", name: "Recipient.phoneNumber" },
                    { data: "channelType", name: "channelType" },
                    { data: "amount", name: "amount" },
                    { data: "reference", name: "reference" },
                    { data:"channelType", name:"Action"},
                ],
                "fnRowCallback": function(nRow, aData){
                    $("td:eq(9)",nRow).html('<a class="job" href="/Transactions/GetDetails?id='+ aData + '" class = "query"> View <a/>');

                    return nRow;
                },
            }
        );
       });