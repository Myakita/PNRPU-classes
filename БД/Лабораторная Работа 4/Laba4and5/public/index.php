<!DOCTYPE html>
<html lang="ru">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>SQL Операции (DDL и DML)</title>
    <style>
        /* Styles reset */
        *, *::before, *::after {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        /* Base styling */
        body, html {
            height: 100%;
            font-family: Arial, sans-serif;
        }

        /* Container layout */
        .container {
            display: flex;
            height: 100vh;
            padding: 20px;
        }

        /* Operations panel styling */
        .operations {
            flex: 1;
            max-width: 300px;
            background-color: #f0f0f0;
            border-radius: 15px;
            padding: 20px;
            overflow-y: auto;
            margin-right: 20px;
        }

        /* Result container styling */
        .result-container {
            flex: 2;
            background-color: #f4f4f4;
            border-radius: 15px;
            padding: 20px;
            overflow-y: hidden;
            min-height: 100%;
        }

        /* Input and button styling */
        input, select, textarea, button {
            margin: 10px 0;
            display: block;
            width: 100%;
        }

        /* Result area styling */
        #result {
            margin-top: 20px;
            padding: 20px;
            background-color: #d3d3d3;
            border-radius: 10px;
            min-height: 200px;
        }

        /* Headers styling */
        h2 {
            font-size: 20px;
            margin-bottom: 15px;
        }

        h3 {
            font-size: 16px;
            margin-top: 15px;
            margin-bottom: 10px;
        }
    </style>
    <script>
        // Function to send requests to the server
        function sendRequest(operation, params) {
            var xhr = new XMLHttpRequest();
            xhr.open("POST", "process.php", true);
            xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

            xhr.onreadystatechange = function() {
                if (xhr.readyState === 4 && xhr.status === 200) {
                    document.getElementById("result").innerHTML = xhr.responseText;
                }
            };

            var data = "operation=" + operation + "&" + new URLSearchParams(params).toString();
            xhr.send(data);
        }
    </script>
</head>
<body>

    <div class="container">
        <!-- SQL Operations Panel -->
        <div class="operations">
            <h2>DDL Команды</h2>

            <h3>CREATE TABLE</h3>
            <input type="text" id="tableName" placeholder="Название таблицы">
            <button onclick="sendRequest('create', { tableName: document.getElementById('tableName').value })">Создать таблицу</button>

            <h3>ALTER TABLE (Добавить столбец)</h3>
            <input type="text" id="alterTableName" placeholder="Название таблицы">
            <input type="text" id="columnName" placeholder="Название столбца">
            <input type="text" id="columnType" placeholder="Тип данных (например, VARCHAR(255))">
            <button onclick="sendRequest('alter', { 
                tableName: document.getElementById('alterTableName').value,
                columnName: document.getElementById('columnName').value,
                columnType: document.getElementById('columnType').value
            })">Добавить столбец</button>

            <h3>DROP TABLE</h3>
            <input type="text" id="dropTableName" placeholder="Название таблицы">
            <button onclick="sendRequest('drop', { tableName: document.getElementById('dropTableName').value })">Удалить таблицу</button>
			
			<h3>TRUNCATE TABLE</h3>
			<input type="text" id="truncateTableName" placeholder="Название таблицы">
			<button onclick="sendRequest('truncate', { tableName: document.getElementById('truncateTableName').value })">Очистить таблицу</button>

            <h2>DML Команды</h2>

            <h3>INSERT INTO</h3>
            <input type="text" id="insertTableName" placeholder="Название таблицы">
            <input type="text" id="insertName" placeholder="ФИО">
            <input type="text" id="insertPhone" placeholder="Телефон">
            <input type="text" id="insertAdress" placeholder="Адрес">
            <input type="text" id="insertYears" placeholder="Труд.Деятельность(года)">
            <input type="number" id="insertSalary" placeholder="ЗП">
            <button onclick="sendRequest('insert', { 
                tableName: document.getElementById('insertTableName').value,
                name: document.getElementById('insertName').value, 
                phone: document.getElementById('insertPhone').value, 
                salary: document.getElementById('insertSalary').value,
                adress: document.getElementById('insertAdress').value,
                years: document.getElementById('insertYears').value
            })">Добавить сотрудника</button>

            <h3>DELETE</h3>
            <input type="text" id="deleteTableName" placeholder="Название таблицы">
            <input type="text" id="deleteName" placeholder="ФИО для удаления">
            <button onclick="sendRequest('delete', { 
                tableName: document.getElementById('deleteTableName').value, 
                name: document.getElementById('deleteName').value 
            })">Удалить сотрудника</button>

            <h3>UPDATE (Изменить ЗП по ФИО)</h3>
            <input type="text" id="updateTableName" placeholder="Название таблицы">
            <input type="text" id="updateName" placeholder="ФИО">
            <input type="number" id="updateSalary" placeholder="Новая ЗП">
            <button onclick="sendRequest('update', { 
                tableName: document.getElementById('updateTableName').value,
                name: document.getElementById('updateName').value, 
                salary: document.getElementById('updateSalary').value 
            })">Изменить ЗП</button>

            <h2>SELECT</h2>
            <input type="text" id="selectTable" placeholder="Название таблицы">
            <button onclick="sendRequest('select', { 
                tableName: document.getElementById('selectTable').value 
            })">Выбрать все данные</button>

            <h2>INNER JOIN</h2>
            <input type="text" id="table1" placeholder="Название первой таблицы">
            <input type="text" id="table2" placeholder="Название второй таблицы">
            <input type="text" id="joinColumn1" placeholder="Столбец для соединения (таблица 1)">
            <input type="text" id="joinColumn2" placeholder="Столбец для соединения (таблица 2)">
            <button onclick="sendRequest('innerJoin', { 
                table1: document.getElementById('table1').value,
                table2: document.getElementById('table2').value,
                joinColumn1: document.getElementById('joinColumn1').value,
                joinColumn2: document.getElementById('joinColumn2').value
            })">Выполнить INNER JOIN</button>

            <!-- Button to view logs -->
            <h2>Логи</h2>
            <button onclick="sendRequest('view_logs', {})">Посмотреть логи SQL операций</button>
        </div>

        <!-- Result Display Area -->
        <div id="result" class="result-container">
            <h2>Результаты выполнения SQL-команд</h2>
            <p>Здесь будут отображаться результаты запросов</p>
        </div>
    </div>

</body>
</html>
