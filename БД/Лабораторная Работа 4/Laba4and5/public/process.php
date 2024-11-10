<?php
$host = 'localhost';
$db = 'mokrushin';
$user = 'root';
$pass = 'lYena00335';

$mysqli = new mysqli($host, $user, $pass, $db);

if ($mysqli->connect_error) {
    die("Ошибка подключения: " . $mysqli->connect_error);
}

$operation = $_POST['operation'] ?? '';

switch ($operation) {
    case 'create':
        $tableName = $_POST['tableName'];
        $sql = "CREATE TABLE $tableName (id INT AUTO_INCREMENT PRIMARY KEY)";
        break;

    case 'alter':
        $tableName = $_POST['tableName'];
        $columnName = $_POST['columnName'];
        $columnType = $_POST['columnType'];
        $sql = "ALTER TABLE $tableName ADD $columnName $columnType";
        break;

    case 'drop':
        $tableName = $_POST['tableName'];
        $sql = "DROP TABLE $tableName";
        break;

    case 'truncate':
        $tableName = $_POST['tableName'];
        $sql = "TRUNCATE TABLE $tableName";
        break;

    case 'insert':
        $tableName = $_POST['tableName'];
        $name = $_POST['name'];
        $phone = $_POST['phone'];
        $salary = $_POST['salary'];
        $address = $_POST['adress'];
        $years = $_POST['years'];
        $sql = "INSERT INTO $tableName (ФИО, Телефон, ЗП, Адрес, Трудовая_деятельность) VALUES ('$name', '$phone', $salary, '$address','$years')";
        break;

    case 'delete':
        $tableName = $_POST['tableName'];
        $name = $_POST['name'];
        $sql = "DELETE FROM $tableName WHERE ФИО = '$name'";
        break;

    case 'update':
        $tableName = $_POST['tableName'];
        $name = $_POST['name'];
        $salary = $_POST['salary'];
        $sql = "UPDATE $tableName SET ЗП = $salary WHERE ФИО = '$name'";
        break;

    case 'select':
        $tableName = $_POST['tableName'];
        $sql = "SELECT * FROM $tableName";
        break;

    case 'view_logs':
        $sql = "SELECT * FROM LOG ORDER BY action_time DESC";
        break;

    default:
        echo "Неверная операция!";
        exit;
}

$result = $mysqli->query($sql);

if ($result && $result instanceof mysqli_result) {
    echo "<table border='1'><tr>";
    while ($fieldinfo = $result->fetch_field()) {
        echo "<th>" . $fieldinfo->name . "</th>";
    }
    echo "</tr>";

    while ($row = $result->fetch_assoc()) {
        echo "<tr>";
        foreach ($row as $value) {
            echo "<td>" . htmlspecialchars($value) . "</td>";
        }
        echo "</tr>";
    }
    echo "</table>";
} else if ($result) {
    echo "Операция выполнена успешно.";
} else {
    echo "Ошибка выполнения SQL: " . $mysqli->error;
}

$mysqli->close();
?>
