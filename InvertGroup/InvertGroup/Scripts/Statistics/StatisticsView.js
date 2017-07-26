$$r(function () {

    getStatistics();
});

function getStatistics() {
    var statisticsList = document.getElementById('statisticList');
    var loadImage = document.getElementById('load');
    loadImage.style.display = 'block';

    var methodName = 'GetStatistics';
    CallServerMethod(methodName, null, function (result) {
        if (result != null && result != '') {
            var tableStatistic = document.createElement('table');
            tableStatistic.style.border = '1px solid black';
            tableStatistic.style.width = '70%';

            var thead = document.createComment('thead');
            var trHead = document.createElement('tr');

            var thEmpty = document.createElement('th');
            thEmpty.style.border = '1px solid black';


            var thVip = document.createElement('th');
            thVip.textContent = 'ВИП';
            thVip.style.textAlign = 'center';
            thVip.style.border = '1px solid black';


            var thTop = document.createElement('th');
            thTop.textContent = 'Топ';
            thTop.style.textAlign = 'center';
            thTop.style.border = '1px solid black';

            var thMiddle = document.createElement('th');
            thMiddle.textContent = 'Средний';
            thMiddle.style.textAlign = 'center';
            thMiddle.style.border = '1px solid black';

            var thUsually = document.createElement('th');
            thUsually.textContent = 'Обычный';
            thUsually.style.textAlign = 'center';
            thUsually.style.border = '1px solid black';

            trHead.appendChild(thEmpty);
            trHead.appendChild(thVip);
            trHead.appendChild(thTop);
            trHead.appendChild(thMiddle);
            trHead.appendChild(thUsually);

            //thead.appendChild(trHead);

            var tbody = document.createElement('tbody');

            var trQuantytiClients = document.createElement('tr');

            var tdQuantytiClients = document.createElement('td');
            tdQuantytiClients.textContent = 'Колличетсво клиентво';
            tdQuantytiClients.style.border = '1px solid black';

            var tdClientVip = document.createElement('td');
            tdClientVip.textContent = result.CountVipClients;
            tdClientVip.style.textAlign = 'center';
            tdClientVip.style.border = '1px solid black';

            var tdClientTop = document.createElement('td');
            tdClientTop.textContent = result.CountTopClients;
            tdClientTop.style.textAlign = 'center';
            tdClientTop.style.border = '1px solid black';

            var tdClientMiddle = document.createElement('td');
            tdClientMiddle.textContent = result.CountMiddleClients;
            tdClientMiddle.style.textAlign = 'center';
            tdClientMiddle.style.border = '1px solid black';


            var tdClientUsually = document.createElement('td');
            tdClientUsually.textContent = result.CountUsuallyClients;
            tdClientUsually.style.textAlign = 'center';
            tdClientUsually.style.border = '1px solid black';

            trQuantytiClients.appendChild(tdQuantytiClients);
            trQuantytiClients.appendChild(tdClientVip);
            trQuantytiClients.appendChild(tdClientTop);
            trQuantytiClients.appendChild(tdClientMiddle);
            trQuantytiClients.appendChild(tdClientUsually);


            var trSum= document.createElement('tr');

            var tdSum = document.createElement('td');
            tdSum.textContent = 'Сумма по всем заказам';
            tdSum.style.border = '1px solid black';

            var tdSumVip = document.createElement('td');
            tdSumVip.textContent = result.VipTotalSum;
            tdSumVip.style.textAlign = 'center';
            tdSumVip.style.border = '1px solid black';

            var tdSumTop = document.createElement('td');
            tdSumTop.textContent = result.TopTotalSum;
            tdSumTop.style.textAlign = 'center';
            tdSumTop.style.border = '1px solid black';

            var tdSumMiddle = document.createElement('td');
            tdSumMiddle.textContent = result.MiddleTotalSum;
            tdSumMiddle.style.textAlign = 'center';
            tdSumMiddle.style.border = '1px solid black';


            var tdSumUsually = document.createElement('td');
            tdSumUsually.textContent = result.UsuallyTotalSum;
            tdSumUsually.style.textAlign = 'center';
            tdSumUsually.style.border = '1px solid black';

            trSum.appendChild(tdSum);
            trSum.appendChild(tdSumVip);
            trSum.appendChild(tdSumTop);
            trSum.appendChild(tdSumMiddle);
            trSum.appendChild(tdSumUsually);

            tbody.appendChild(trQuantytiClients);
            tbody.appendChild(trSum);

            tableStatistic.appendChild(trHead);
            tableStatistic.appendChild(tbody);

            loadImage.style.display = 'none';


            statisticsList.appendChild(tableStatistic);
        }
    });
}

function CallServerMethod(methodName, args, onsucces, onerror) {
    $.ajax({
        url: '/Statistics/' + methodName,
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