$$r(function () {
    var pageUrl = document.URL;
    var clientId = _GetParametrFromUrl(pageUrl, 'Id');

    if (clientId != '') {
        getAllOrderByClient(clientId);
    }
});


function getAllOrderByClient(clientId)
{
    var ordersList = document.getElementById('ordersList');

    var loadImage = document.getElementById('load');
    loadImage.style.display = 'block';

    var request = {};
    request.ClientCode = clientId;
    var methodName = 'GetDetailsOrders';
    CallServerMethod(methodName, JSON.stringify(request), function (result) {
        if (result.length != 0) {
            result.forEach(function (item, i) {
                var divHead = document.createElement('div');
                divHead.style.width = '50%';
                divHead.style.height = '80px';
                divHead.style.display = 'block';
                divHead.style.lineHeight = '80px';
                divHead.style.fontWeight = 'bold';

                var divOrderCode = document.createElement('div');
                divOrderCode.style.width = '48%';
                divOrderCode.style.height = '100%';
                divOrderCode.style.display = 'inline-block';
                divOrderCode.textContent = 'Заказ № '+item.Order.OrderCode;


                var divOrderDate = document.createElement('div');
                divOrderDate.style.width = '48%';
                divOrderDate.style.height = '100%';
                divOrderDate.style.display = 'inline-block';
                divOrderDate.textContent = 'Дата заказа:' + item.OrderDate;

                divHead.appendChild(divOrderCode);
                divHead.appendChild(divOrderDate);

                ordersList.appendChild(divHead);
                if (item.DetailOrederString.length != 0) {

                    var tableOrder = document.createElement('table');
                    tableOrder.style.width = '70%';
                    tableOrder.style.border = '1px solid black';

                    var thead = document.createElement('thead');

                    var trHead = document.createElement('tr');


                    var thProduct = document.createElement('th');
                    thProduct.style.textAlign = 'center';
                    thProduct.textContent = 'Товары';

                    var thPrice = document.createElement('th');
                    thPrice.style.textAlign = 'center';
                    thPrice.textContent = 'Цена';

                    var thQuantity = document.createElement('th');
                    thQuantity.style.textAlign = 'center';
                    thQuantity.textContent = 'Количество';

                    var thTotalAmount = document.createElement('th');
                    thTotalAmount.style.textAlign = 'center';
                    thTotalAmount.textContent = 'Общая цена';

                    trHead.appendChild(thProduct);
                    trHead.appendChild(thPrice);
                    trHead.appendChild(thQuantity);
                    trHead.appendChild(thTotalAmount);

                    thead.appendChild(trHead);


                    var tbodyOrder = document.createElement('tbody');

                    item.DetailOrederString.forEach(function (tableItem, i) {
                        var trBody = document.createElement('tr');

                        var tdProduct = document.createElement('td');
                        tdProduct.textContent = tableItem.ProductName;
                        tdProduct.style.border = '1px solid black';
                        tdProduct.style.textAlign = 'center';

                        var tdPrice = document.createElement('td');
                        tdPrice.textContent = tableItem.Price;
                        tdPrice.style.border = '1px solid black';
                        tdPrice.style.textAlign = 'center';

                        var tdQuantity = document.createElement('td');
                        tdQuantity.textContent = tableItem.Quantity;
                        tdQuantity.style.border = '1px solid black';
                        tdQuantity.style.textAlign = 'center';

                        var tdTotalAmount = document.createElement('td');
                        tdTotalAmount.textContent = tableItem.TotalAmount;
                        tdTotalAmount.style.border = '1px solid black';
                        tdTotalAmount.style.textAlign = 'center';

                        trBody.appendChild(tdProduct);
                        trBody.appendChild(tdPrice);
                        trBody.appendChild(tdQuantity);
                        trBody.appendChild(tdTotalAmount);

                        tbodyOrder.appendChild(trBody);

                        tableOrder.appendChild(thead);
                        tableOrder.appendChild(tbodyOrder);
                    });
                    loadImage.style.display = 'none';

                    ordersList.appendChild(tableOrder);
                }
            });
        }
    });
}


function _GetParametrFromUrl(locationString, name) {
    name = name.replace(/[\[]/, '\\\[').replace(/[\]]/, '\\\]');
    var regexS = '[\\?&]' + name + '=([^&#]*)';
    var regex = new RegExp(regexS);
    var results = regex.exec(locationString);
    if (results == null)
        return '';
    else
        return decodeURIComponent(results[1].replace(/\+/g, ' '));
}

function CallServerMethod(methodName, args, onsucces, onerror) {
    $.ajax({
        url: '/OrdersByClient/' + methodName,
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