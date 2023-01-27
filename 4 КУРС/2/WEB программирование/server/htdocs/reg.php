<?php
$mysqli = new mysqli("localhost","root","root","shop");

// Check connection
if ($mysqli -> connect_errno) {
  echo "Failed to connect to MySQL: " . $mysqli -> connect_error;
  exit();
}
$user = $_GET["userName"];
$result = $mysqli->query("INSERT INTO `users` (`id`, `name`, `orders`) VALUES (NULL, '".$user."', '')");
print($result);
?>