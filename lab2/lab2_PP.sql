-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Апр 16 2019 г., 10:46
-- Версия сервера: 5.6.38
-- Версия PHP: 5.6.32

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `lab2_PP`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Client`
--

CREATE TABLE `Client` (
  `id` int(11) NOT NULL,
  `fio` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Client`
--

INSERT INTO `Client` (`id`, `fio`) VALUES
(1, 'Панфилов Денис Игоревич'),
(2, 'Кубарь Александр Сергеевич'),
(3, 'Жилин Даниил Игоревич');

-- --------------------------------------------------------

--
-- Структура таблицы `Usluga`
--

CREATE TABLE `Usluga` (
  `id` int(11) NOT NULL,
  `nazvanie` varchar(50) NOT NULL,
  `cena` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Usluga`
--

INSERT INTO `Usluga` (`id`, `nazvanie`, `cena`) VALUES
(1, 'Чистка обуви', 300),
(2, 'Мытье полов', 500),
(3, 'Замена батарейки', 720);

-- --------------------------------------------------------

--
-- Структура таблицы `Zayavka`
--

CREATE TABLE `Zayavka` (
  `id` int(11) NOT NULL,
  `client_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Zayavka`
--

INSERT INTO `Zayavka` (`id`, `client_id`) VALUES
(1, 3),
(2, 1),
(3, 2);

-- --------------------------------------------------------

--
-- Структура таблицы `Zayavka_Usluga`
--

CREATE TABLE `Zayavka_Usluga` (
  `zayavka_id` int(11) NOT NULL,
  `usluga_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Zayavka_Usluga`
--

INSERT INTO `Zayavka_Usluga` (`zayavka_id`, `usluga_id`) VALUES
(1, 2),
(2, 3),
(3, 1);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Client`
--
ALTER TABLE `Client`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `Usluga`
--
ALTER TABLE `Usluga`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `Zayavka`
--
ALTER TABLE `Zayavka`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Client`
--
ALTER TABLE `Client`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `Usluga`
--
ALTER TABLE `Usluga`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `Zayavka`
--
ALTER TABLE `Zayavka`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
