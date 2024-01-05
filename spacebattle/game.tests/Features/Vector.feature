﻿Функция: Вектор n-мерного веторного пространства
Для описания атрибутов объекта - положение в пространстве, мгновенная скоровть 
используются объекты класса Vector.

@позитивный
Сценарий: Два веткора можно сложить
	Дано двухмерный вектор a с координатами (2, 3)
	И двухмерный вектор b с координатами (2, -1)
	Когда складываем веторы a и b
	Тогда получаем вектор с координатами (4, 2).

@негативный
Сценарий: Два вектора разной размерности складывать нельзя
    Дано двухмерный вектор a с координатами (2, 3)
	И трехмерный вектор b с координатами (2, -1, 0)
	Когда складываем веторы a и b
	Тогда выбрасывается исключение