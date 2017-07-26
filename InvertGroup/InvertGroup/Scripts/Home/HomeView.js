$$r(function () {
    
    getAllClient();
});


function getAllClient() {
    var loadImage = document.getElementById('load');
    loadImage.style.display = 'block';
    var methodName = "GetAllClients";
    var tableClient = document.getElementById('tableClient');
    CallServerMethod(methodName, null, function (result) {
        if (result.length != 0) {
            var trHead = document.createElement('tr');
            var thEmpty = document.createElement('th');
            var thName = document.createElement('th');
            thName.textContent = 'Фамилия и имя клиента'
            var thAdress = document.createElement('th');
            thAdress.textContent = 'Адрес';
            var thTotalAmount = document.createElement('th');
            thTotalAmount.textContent = 'Общая сумма по заказам';

            trHead.appendChild(thEmpty);
            trHead.appendChild(thName);
            trHead.appendChild(thAdress);
            trHead.appendChild(thTotalAmount);



            var tbody = document.createElement('tbody');

            result.forEach(function (item, i) {
                var trClient = document.createElement('tr');

                var tdId = document.createElement('td');
                tdId.textContent = item.Id;

                var tdName = document.createElement('td');

                var aName = document.createElement('a');
                aName.href = '../../OrdersByClient/OrdersByClient?&Id=' + item.Id;
                aName.textContent = item.Name;

                var tdAdress = document.createElement('td');
                tdAdress.textContent = item.Adress;

                var tdTotalAmountByOrders = document.createElement('td');
                tdTotalAmountByOrders.textContent = item.TotalAmountByOrders;

                tdName.appendChild(aName);

                trClient.appendChild(tdId);
                trClient.appendChild(tdName);
                trClient.appendChild(tdAdress);
                trClient.appendChild(tdTotalAmountByOrders);

                tbody.appendChild(trClient);

                loadImage.style.display = 'none';

                tableClient.appendChild(trHead);
                tableClient.appendChild(tbody);

            });
        }
    });
}

function CallServerMethod(methodName, args, onsucces, onerror) {
    $.ajax({
        url: '/Home/' + methodName,
        type: "POST",
        async: true,
        cache: false,
        dataType: "json",
        data: "{'args':'" + args + "'}",
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            onsucces(result);
        },
        error: function (e) {
            onerror(e);
        }
    });
}