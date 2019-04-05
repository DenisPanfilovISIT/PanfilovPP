<?php

function Index($filename, $response)//функция сохранения
{
	$url = $_SERVER['HTTP_HOST'] . $_SERVER['REQUEST_URI'];
	$index = array(
		'url' => $url,
		'response' => $response,
		'method' => $_SERVER['REQUEST_METHOD']);

	$json_example = json_encode($index, JSON_UNESCAPED_UNICODE | JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES);
	file_put_contents($filename, $json_example . "\n", FILE_APPEND | LOCK_EX);
}
?>