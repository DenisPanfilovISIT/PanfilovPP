<?php

$url = $url = 'http://' . $_SERVER['HTTP_HOST'] . $_SERVER['REQUEST_URI'];

$ssylka = (parse_url($url));
$path = $ssylka["path"];
$path = explode('/', $path);
isset($ssylka['query']) && parse_str($ssylka['query'], $_GET);
for ($i = 1; $i < (count($path) - 1); $i++) {
    $path[$i] = urldecode($path[$i]);
}


$api_res='http://www.mocky.io/v2/5c7db5e13100005a00375fda';
$api=json_decode(file_get_contents($api_res),true);


$file = file_get_contents('lab_4.json');
$list = json_decode($file, true);
unset($file);

$result=str_replace(' ','_',$api);


$list[] = array('url' => $url, 'response' => $result, 'method' => $_SERVER['REQUEST_METHOD']);
file_put_contents('lab_4.json', json_encode($list));
unset($list);
?>

