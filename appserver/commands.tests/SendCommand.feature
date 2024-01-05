﻿Функция: Команда, которая отправляет команду потребителю команд.

@позитивный
Сценарий: Метод Execute отправляет команду в потребитель команд
	Дано Команда Send
	Когда Команда Send выполняется
	Тогда Команда переданная в Send в конструкторе передается в потребитель команд

@негативный
Сценарий: Метод Execute выбрасывает исключение
	Дано Команда Send
	И Потребитель команд выбрасывает исключение
	Когда Команда Send выполняется
	Тогда Команда Send прерывается выбросом исключения
