<!DOCTYPE html>
<html lang="ru">
<head>
    <meta charset="UTF-8">
    <title>Запросы к базе данных</title>
    <style>
        .button {
            padding: 10px 20px;
            margin: 10px;
            font-size: 16px;
            cursor: pointer;
        }
        #output {
            margin-top: 20px;
            padding: 20px;
            background-color: #d3d3d3;
            border-radius: 10px;
            min-height: 100px;
        }
    </style>
    <script>
        function runQuery(queryNumber) {
            var xhr = new XMLHttpRequest();
            xhr.open("POST", "process.php", true);
            xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            xhr.onreadystatechange = function() {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    document.getElementById("output").innerHTML = xhr.responseText;
                }
            };
            xhr.send("query=" + queryNumber);
        }
    </script>
</head>
<body>

    <h1>Выполнение SQL запросов</h1>
    
    <!-- Кнопки для выполнения запросов -->
    <button class="button" onclick="runQuery(1)">Запрос 1</button>
    <button class="button" onclick="runQuery(2)">Запрос 2</button>
    <button class="button" onclick="runQuery(3)">Запрос 3</button>

    <div id="output">
        <p>Здесь будут отображаться результаты запросов</p>
    </div>

</body>
</html>
