<?php 
	//連線(伺服器位置，資料庫帳號，資料庫密碼，資料庫名稱)
	//$connect = mysqli_connect("localhost","id18085002_ce777","h5YM9IppELdrg]c","id18085002_unity_db");
		$connect = mysqli_connect("localhost","id18085002_ce_db","h5YM9IppELdrg~c","id18085002_unity_db");
		
	//金幣變數 = Unity 透過POST 傳輸資料.名稱為coin的資料
	$coin = $_POST["coin"];     //"自行定義"
	$posX = $_POST["posX"];     //"自行定義"
	$posY = $_POST["posY"];     //"自行定義"
	
	
	
	
	//更新 Playerdata 編號1的金幣為50
	//更新 Playerdata 設定coin = 50 位置在playerdaata.id = 1
	//$sql = "UPDATE `PlayerData` SET `coin` = '50' WHERE `PlayerData`.`id` = 1;"
	$sqlCoin = "UPDATE `PlayerData` SET `coin` = '".$coin."' WHERE `PlayerData`.`id` = 1";
	$posX = "UPDATE `PlayerData` SET `posX` = '".$posX."' WHERE `PlayerData`.`id` = 1";
	$posY = "UPDATE `PlayerData` SET `posY`` = '".$posY."' WHERE `PlayerData`.`id` = 1";

	
	//執行SQL(連線資料,查詢資料)
	mysql_query($connect,$sqlCoin);
	mysql_query($connect,$posX);
	mysql_query($connect,$posY);
	
	
	
?>