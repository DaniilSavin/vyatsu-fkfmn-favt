<?php

$mysqli = new mysqli("localhost","root","root","shop");
// Check connection
if ($mysqli -> connect_errno) {
  echo "Failed to connect to MySQL: " . $mysqli -> connect_error;
  exit();
}
$user = $_GET["userName"];

$result = $mysqli->query("SELECT * FROM `orders` WHERE `userName` LIKE '".$user."' ORDER BY `userName` ASC");

$array = array();
while( $row = $result->fetch_array())
{
    $result2= $mysqli->query("SELECT * FROM `items` WHERE `id` = ".$row[1]);
    $row2 = $result2->fetch_array();
    //print_r($row);
    array_push($array,['id'=>$row[0],'itemId'=>$row[1],'username'=>$row[2],'itemName'=>$row2[1],'time'=>$row[3]]);
}
print(json_encode($array));
?>