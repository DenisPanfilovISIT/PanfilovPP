<?php
$link = mysqli_connect("localhost", "root", "", "lab2_PP");
$url = $url = 'http://' . $_SERVER['HTTP_HOST'] . $_SERVER['REQUEST_URI'];

$ur = (parse_url($url));
$path = $ur["path"];
//echo $path;
$path = explode('/', $path);
isset($ur['query']) && parse_str($ur['query'], $_GET);
for ($i = 1; $i < (count($path) - 1); $i++) {
    $path[$i] = urldecode($path[$i]);
}

$possible_url = array("delete", "put", "get", "post");

$file = file_get_contents('lab_2.json');

$list = json_decode($file, true);

unset($file);
$result='';
if ($path[2] == "Client") {
    if (isset($_GET["action"]) && in_array($_GET["action"], $possible_url)) {
        switch ($_GET["action"]) {

            case "delete":
                if (isset($_GET["id"])) {
                    $id = $_GET["id"];
//                    echo $id;
                    $result = mysqli_query($link, "CALL DelClient($id)");
                    $list[] = array('url' => $url, 'response' => $result, 'method' => $_SERVER['REQUEST_METHOD']);
                    file_put_contents('lab_2.json', json_encode($list));
                    unset($list);

                }
                break;

            case "put":
                if (isset($_GET["fio"]) && isset($_GET["id"])) {
                    $fio = $_GET["fio"];
                    $id = $_GET["id"];
                    (mysqli_query($link, "CALL UpdClient('$fio',$id)"));
                    $list[] = array('url' => $url, 'response' => $result, 'method' => $_SERVER['REQUEST_METHOD']);
                    file_put_contents('lab_2.json', json_encode($list));
                    unset($list);
                }
                break;

            case "post":
                if ($fio = $_GET["fio"]) {
                    (mysqli_query($link, "CALL InsClient('$fio')"));
                    $list[] = array('url' => $url, 'response' => $result, 'method' => $_SERVER['REQUEST_METHOD']);
                    file_put_contents('lab_2.json', json_encode($list));
                    unset($list);
                }
                break;

            case "get":
                if ($id = $_GET["id"]) {
                    $result = mysqli_fetch_all(mysqli_query($link, "CALL SelClient($id)"), MYSQLI_ASSOC);
                    $list[] = array('url' => $url, 'response' => $result, 'method' => $_SERVER['REQUEST_METHOD']);
                    file_put_contents('lab_2.json', json_encode($list));
                    unset($list);
//                    var_dump($result);
                } else {
                    $result = mysqli_fetch_all(mysqli_query($link, "CALL SelKlients"), MYSQLI_ASSOC);
                    $list[] = array('url' => $url, 'response' => $result, 'method' => $_SERVER['REQUEST_METHOD']);
                    file_put_contents('lab_2.json', json_encode($list));
                    unset($list);
//                    var_dump($result);
                }
                break;
        }
    }
}

if ($path[2] == "Zayavka") {
    if (isset($_GET["action"]) && in_array($_GET["action"], $possible_url)) {
        switch ($_GET["action"]) {

            case "delete":
                if (isset($_GET["id"])) {
                    $id = $_GET["id"];
//                    echo $id;
                    mysqli_query($link, "CALL DelZayavka($id)");
                    $list[] = array('url' => $url, 'response' => $result, 'method' => $_SERVER['REQUEST_METHOD']);
                    file_put_contents('lab_2.json', json_encode($list));
                    unset($list);
                }
                break;

            case "put":
                if (isset($_GET["client_id"]) && isset($_GET["id"])) {
                    $client = $_GET["client_id"];
                    $id = $_GET["id"];
                    $result = (mysqli_query($link, "CALL UpdZayavka($client,$id)"));
                    $list[] = array('url' => $url, 'response' => $result, 'method' => $_SERVER['REQUEST_METHOD']);
                    file_put_contents('lab_2.json', json_encode($list));
                    unset($list);
                }
                break;

            case "post":
                if ($id = $_GET["id"]) {
                    $result = (mysqli_query($link, "CALL InsZayavka($id)"));
                    $list[] = array('url' => $url, 'response' => $result, 'method' => $_SERVER['REQUEST_METHOD']);
                    file_put_contents('lab_2.json', json_encode($list));
                    unset($list);
                }
                break;

            case "get":
                if ($id = $_GET["id"]) {
                    $result = mysqli_fetch_all(mysqli_query($link, "CALL SelZayavku($id)"), MYSQLI_ASSOC);
                    $list[] = array('url' => $url, 'response' => $result, 'method' => $_SERVER['REQUEST_METHOD']);
                    file_put_contents('lab_2.json', json_encode($list));
                    unset($list);
//                    var_dump($result);
                } else {
                    $result = mysqli_fetch_all(mysqli_query($link, "CALL SelZayavki"), MYSQLI_ASSOC);
                    $list[] = array('url' => $url, 'response' => $result, 'method' => $_SERVER['REQUEST_METHOD']);
                    file_put_contents('lab_2.json', json_encode($list));
                    unset($list);
//                    var_dump($result);
                }
                break;
        }
    }
}

if ($path[2] == "Usluga") {
    if (isset($_GET["action"]) && in_array($_GET["action"], $possible_url)) {
        switch ($_GET["action"]) {

            case "delete":
                if (isset($_GET["id"])) {
                    $id = $_GET["id"];
                    echo $id;
                    $result = mysqli_query($link, "CALL DelUsluga($id)");
                    $list[] = array('url' => $url, 'response' => $result, 'method' => $_SERVER['REQUEST_METHOD']);
                    file_put_contents('lab_2.json', json_encode($list));
                    unset($list);
                }
                break;

            case "put":
                if (isset($_GET["id"]) && isset($_GET["nazvanie"]) && isset($_GET["cena"])) {
                    $nazvanie = $_GET["nazvanie"];
                    $id = $_GET["id"];
                    $cena = $_GET["price"];
                    $result = (mysqli_query($link, "CALL UpdClient($id,'$nazvanie',$cena)"));
                    $list[] = array('url' => $url, 'response' => $result, 'method' => $_SERVER['REQUEST_METHOD']);
                    file_put_contents('lab_2.json', json_encode($list));
                    unset($list);
                }
                break;

            case "post":
                if (isset($_GET["nazvanie"]) && isset($_GET["cena"])) {
                    $cena = $_GET["price"];
                    $nazvanie = $_GET["name"];
                    $result = (mysqli_query($link, "CALL InsUsluga('$nazvanie',$cena)"));
                    $list[] = array('url' => $url, 'response' => $result, 'method' => $_SERVER['REQUEST_METHOD']);
                    file_put_contents('lab_2.json', json_encode($list));
                    unset($list);
                }
                break;

            case "get":
                if ($id = $_GET["id"]) {
                    $result = mysqli_fetch_all(mysqli_query($link, "CALL SelUsluga($id)"), MYSQLI_ASSOC);
                    $list[] = array('url' => $url, 'response' => $result, 'method' => $_SERVER['REQUEST_METHOD']);
                    file_put_contents('lab_2.json', json_encode($list));
                    unset($list);
//                    var_dump($result);
                } else {
                    $result = mysqli_fetch_all(mysqli_query($link, "CALL SelUslugi"), MYSQLI_ASSOC);
                    $list[] = array('url' => $url, 'response' => $result, 'method' => $_SERVER['REQUEST_METHOD']);
                    file_put_contents('lab_2.json', json_encode($list));
                    unset($list);
//                    var_dump($result);
                }
                break;
        }
    }
}

?>
