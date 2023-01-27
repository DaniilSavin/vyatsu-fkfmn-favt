<?php

$mysqli = new mysqli("localhost","root","root","shop");

// Check connection
if ($mysqli -> connect_errno) {
  echo "Failed to connect to MySQL: " . $mysqli -> connect_error;
  exit();
}
$result = $mysqli->query("SELECT * FROM `items`");
$array = array();
while( $row = $result->fetch_array() )
{
    //echo $row[2];
    array_push($array,['id'=>$row[0],'name'=>$row[1],'price'=>$row[2]]);
}
print(json_encode($array));

?>