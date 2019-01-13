-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3307
-- Время создания: Дек 19 2018 г., 05:32
-- Версия сервера: 5.6.41
-- Версия PHP: 5.5.38

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `bookstore`
--

-- --------------------------------------------------------

--
-- Структура таблицы `admin`
--

CREATE TABLE `admin` (
  `idorder` int(11) NOT NULL,
  `iddeliver` int(11) NOT NULL,
  `name` varchar(40) NOT NULL,
  `surmane` varchar(40) NOT NULL,
  `login` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `book`
--

CREATE TABLE `book` (
  `idbook` int(11) NOT NULL,
  `author` varchar(40) NOT NULL,
  `name` varchar(40) NOT NULL,
  `price` int(11) NOT NULL,
  `count` int(11) NOT NULL,
  `description` varchar(400) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `book`
--

INSERT INTO `book` (`idbook`, `author`, `name`, `price`, `count`, `description`) VALUES
(1, 'Джоан Роулинг', 'Гарри Поттер', 300, 100, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.'),
(2, 'Стивен Кинг', 'Сияние', 100, 100, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(3, 'Ремарк', 'Триумфальная Арка', 250, 100, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(4, 'Ден Браун', 'Код да Винчи', 500, 95, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(5, 'Лермонтов', 'Герой нашего времени', 280, 300, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(6, 'Самоучитель', 'Английский', 150, 100, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(7, 'Самоучитель', 'Арабский', 99, 100, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(8, 'Самоучитель', 'Китайский', 180, 100, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(9, 'Самоиздательство', 'Английский', 70, 99, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(10, 'Хемингуэй', 'Старик и море', 180, 50, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(11, 'Адам ФРимен', 'Jquery', 230, 30, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(12, 'Андрей Хейлсберг', 'C#', 210, 20, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(13, 'Артур Конан Дойл', 'Шерлок Холмс', 340, 150, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(14, 'Брем Стокер', 'Граф Дракула', 130, 100, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(15, 'Дейл Карнеги', 'Как завоевать друзей', 360, 200, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(16, 'Джон Даккет', 'HTML & CSS', 190, 30, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(17, 'Дмитрий Котеров', 'PHP', 250, 11, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(18, 'Евдокимов', 'Java', 270, 100, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(19, 'Марвин Хаммер', 'Выразительный Javascript', 280, 15, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(20, 'Мэри Шелли', 'Франкенштейн', 180, 150, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(21, 'Рей Бредбери', '451° по Фаренгейту', 480, 100, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(22, 'Рендал Шварц', 'Perl', 280, 40, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(23, 'Самоучитель', 'Иврит', 185, 50, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(24, 'Самоучитель', 'Ирландский', 190, 20, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(25, 'Самоучитель', 'Испанский', 130, 140, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(26, 'Самоучитель', 'Итальянский', 175, 100, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(27, 'Самоучитель', 'Монгольский', 75, 100, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(28, 'Самоучитель', 'Немецкий', 120, 100, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(29, 'Самоучитель', 'Норвежский', 210, 100, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(30, 'Самоучитель', 'Польский', 90, 100, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(31, 'Самоучитель', 'Португальский', 127, 100, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(32, 'Самоучитель', 'Русский', 30, 100, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(33, 'Самоучитель', 'Турецкий', 170, 100, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(34, 'Самоучитель', 'Украинский', 100, 100, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(35, 'Самоучитель', 'Французский', 110, 100, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(36, 'Самоучитель', 'Чистый код', 200, 100, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(37, 'Самоучитель', 'Японский', 245, 100, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(38, 'Тарас Шевченко', 'Кобзар', 800, 95, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.'),
(39, 'Шекспир', 'Сонеты', 350, 40, 'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Blanditiis culpa, quam asperiores, quidem laborum doloremque! Ab, quod architecto temporibus molestiae error dicta, porro magni assumenda, provident a non aspernatur aliquid.');

-- --------------------------------------------------------

--
-- Структура таблицы `cus_order`
--

CREATE TABLE `cus_order` (
  `idorder` int(11) NOT NULL,
  `idbooks` int(11) NOT NULL,
  `count` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `delivery`
--

CREATE TABLE `delivery` (
  `id_receiver` int(11) NOT NULL,
  `id_books` int(11) NOT NULL,
  `total_suma` int(11) NOT NULL,
  `mobile_phone` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `pokupka`
--

CREATE TABLE `pokupka` (
  `idpokupka` int(11) NOT NULL,
  `idorder` int(11) NOT NULL,
  `data_customer` varchar(40) NOT NULL,
  `phone` varchar(15) NOT NULL,
  `general_price` int(11) NOT NULL,
  `date_pokupka` date NOT NULL,
  `address` varchar(40) NOT NULL,
  `payment_metod` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `receiver`
--

CREATE TABLE `receiver` (
  `id_receiv` int(11) NOT NULL,
  `name` varchar(40) NOT NULL,
  `surname` varchar(40) NOT NULL,
  `address` varchar(60) NOT NULL,
  `mobile_phone` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Структура таблицы `user`
--

CREATE TABLE `user` (
  `id_user` int(11) NOT NULL,
  `name` varchar(40) NOT NULL,
  `surmane` varchar(40) NOT NULL,
  `login` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `admin`
--
ALTER TABLE `admin`
  ADD UNIQUE KEY `idorder` (`idorder`),
  ADD UNIQUE KEY `iddeliver` (`iddeliver`);

--
-- Индексы таблицы `book`
--
ALTER TABLE `book`
  ADD PRIMARY KEY (`idbook`),
  ADD KEY `idbook` (`idbook`) USING BTREE;

--
-- Индексы таблицы `cus_order`
--
ALTER TABLE `cus_order`
  ADD PRIMARY KEY (`idorder`),
  ADD UNIQUE KEY `idbooks` (`idbooks`);

--
-- Индексы таблицы `delivery`
--
ALTER TABLE `delivery`
  ADD PRIMARY KEY (`id_receiver`),
  ADD UNIQUE KEY `id_books` (`id_books`);

--
-- Индексы таблицы `pokupka`
--
ALTER TABLE `pokupka`
  ADD PRIMARY KEY (`idpokupka`),
  ADD KEY `data_customer` (`data_customer`),
  ADD KEY `idorder` (`idorder`);

--
-- Индексы таблицы `receiver`
--
ALTER TABLE `receiver`
  ADD PRIMARY KEY (`id_receiv`);

--
-- Индексы таблицы `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id_user`),
  ADD KEY `id_user` (`id_user`);

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `admin`
--
ALTER TABLE `admin`
  ADD CONSTRAINT `admin_ibfk_1` FOREIGN KEY (`iddeliver`) REFERENCES `delivery` (`id_books`);

--
-- Ограничения внешнего ключа таблицы `cus_order`
--
ALTER TABLE `cus_order`
  ADD CONSTRAINT `cus_order_ibfk_1` FOREIGN KEY (`idbooks`) REFERENCES `book` (`idbook`),
  ADD CONSTRAINT `cus_order_ibfk_2` FOREIGN KEY (`idorder`) REFERENCES `admin` (`idorder`);

--
-- Ограничения внешнего ключа таблицы `delivery`
--
ALTER TABLE `delivery`
  ADD CONSTRAINT `delivery_ibfk_1` FOREIGN KEY (`id_receiver`) REFERENCES `receiver` (`id_receiv`);

--
-- Ограничения внешнего ключа таблицы `pokupka`
--
ALTER TABLE `pokupka`
  ADD CONSTRAINT `pokupka_ibfk_1` FOREIGN KEY (`idorder`) REFERENCES `cus_order` (`idorder`);

--
-- Ограничения внешнего ключа таблицы `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `user_ibfk_1` FOREIGN KEY (`id_user`) REFERENCES `pokupka` (`idpokupka`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
