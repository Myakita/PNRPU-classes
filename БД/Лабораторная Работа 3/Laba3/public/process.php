<?php
$host = 'localhost';
$db   = 'mokrushin';
$user = 'root';
$pass = 'lYena00335';

$mysqli = new mysqli($host, $user, $pass, $db);

if ($mysqli->connect_error) {
    die("Ошибка подключения: " . $mysqli->connect_error);
}

$queryNumber = isset($_POST['query']) ? intval($_POST['query']) : 0;

switch ($queryNumber) {
    case 1:
        $sql = "SELECT ФИО, Телефон, ЗП FROM сотрудники"; 
        break;
    case 2:
        $sql = "SELECT ФИО, Адрес FROM сотрудники ORDER BY Адрес asc";
        break;
    case 3:
        $sql = "SELECT ФИО, Трудовая_деятельность FROM сотрудники WHERE Трудовая_деятельность > 4";
        break;
    default:
        echo "Неверный запрос!";
        exit;
}

$result = $mysqli->query($sql);

if ($result && $result->num_rows > 0) {
    echo "<table border='1'><tr>";
    while ($fieldinfo = $result->fetch_field()) {
        echo "<th>" . $fieldinfo->name . "</th>";
    }
    echo "</tr>";
    while ($row = $result->fetch_assoc()) {
        echo "<tr>";
        foreach ($row as $value) {
            echo "<td>" . $value . "</td>";
        }
        echo "</tr>";
    }
    echo "</table>";
} else {
    echo "Нет данных для отображения.";
}
$mysqli->close();
?>
