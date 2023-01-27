<?php
$mysqli = new mysqli("localhost","root","root","shop");
print_r("123123");
// Check connection
if ($mysqli -> connect_errno) {
  echo "Failed to connect to MySQL: " . $mysqli -> connect_error;
  exit();
}
$user = $_GET["userName"];
$itemId = $_GET["itemId"]; 
$result = $mysqli->query("INSERT INTO `orders`(`id`, `itemId`, `userName`, `date`) VALUES (NULL, '".$itemId."', '".$user."', NOW())");

echo $result;
#$result = $mysqli->query("UPDATE `users` SET `orders` = '.$itemId.' WHERE `users`.`name` = '.$user.'");
echo $result;
?>