<?php 
	//連線(伺服器位置，資料庫帳號，資料庫密碼，資料庫名稱)
	//$connect = mysqli_connect("localhost","id18085002_ce777","h5YM9IppELdrg~c","id18085002_unity_db");
	$connect = mysqli_connect("localhost","id18085002_ce_db","h5YM9IppELdrg~c","id18085002_unity_db");
	
	//Unity 要查詢的資料 search欄位 
	//$search = $_POST["search];
	
	$search = "coin";
	//SQL查詢
	$sql = "SELECT `".$search."` FROM `PlayerData` WHERE 1";
	
	//查詢結果
	$result = mysqli_query($connect,$sql);
	
	//輸出 查詢結果 到網頁頁面上
	echo $result;
	
?>