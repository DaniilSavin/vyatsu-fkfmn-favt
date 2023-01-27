<?php
$mysqli = new mysqli("localhost","root","root","shop");

// Check connection
if ($mysqli -> connect_errno) {
  echo "Failed to connect to MySQL: " . $mysqli -> connect_error;
  exit();
}
$user = $_GET["userName"];
$itemId = $_GET["itemId"]; 
$result = $mysqli->query("INSERT INTO `orders` (`id`, `itemId`, `creator`, `comment`, `time`) VALUES (NULL, '".$itemId."', '".$user."', 'COMMENT', NOW())");
echo $result;
#$result = $mysqli->query("UPDATE `users` SET `orders` = '.$itemId.' WHERE `users`.`name` = '.$user.'");
echo $result;
?>