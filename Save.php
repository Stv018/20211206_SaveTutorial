<?php 
	//�s�u(���A����m�A��Ʈw�b���A��Ʈw�K�X�A��Ʈw�W��)
	//$connect = mysqli_connect("localhost","id18085002_ce777","h5YM9IppELdrg]c","id18085002_unity_db");
		$connect = mysqli_connect("localhost","id18085002_ce_db","h5YM9IppELdrg~c","id18085002_unity_db");
		
	//�����ܼ� = Unity �z�LPOST �ǿ���.�W�٬�coin�����
	$coin = $_POST["coin"];     //"�ۦ�w�q"
	$posX = $_POST["posX"];     //"�ۦ�w�q"
	$posY = $_POST["posY"];     //"�ۦ�w�q"
	
	
	
	
	//��s Playerdata �s��1��������50
	//��s Playerdata �]�wcoin = 50 ��m�bplayerdaata.id = 1
	//$sql = "UPDATE `PlayerData` SET `coin` = '50' WHERE `PlayerData`.`id` = 1;"
	$sqlCoin = "UPDATE `PlayerData` SET `coin` = '".$coin."' WHERE `PlayerData`.`id` = 1";
	$posX = "UPDATE `PlayerData` SET `posX` = '".$posX."' WHERE `PlayerData`.`id` = 1";
	$posY = "UPDATE `PlayerData` SET `posY`` = '".$posY."' WHERE `PlayerData`.`id` = 1";

	
	//����SQL(�s�u���,�d�߸��)
	mysql_query($connect,$sqlCoin);
	mysql_query($connect,$posX);
	mysql_query($connect,$posY);
	
	
	
?>