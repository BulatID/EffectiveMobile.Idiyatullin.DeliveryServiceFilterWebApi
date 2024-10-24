# Web API для службы доставки, которое фильтрует заказы в зависимости от количества обращений в конкретном районе города и времени обращения

## POST-запросы (application/json)
### /Order/Filter
#### Получает отфильтрованный список заказов
##### string CityDistrict, DateTime FirstDeliveryDateTime

### /Order/Create
#### Создает новый заказ
##### double Weight, string District, DateTime DeliveryTime

### /Order/Delete
#### Удаляет заказ
##### guid Id

### /Order/Update
#### Обновляет существующий заказ
##### guid Id, double Weight, string District, DateTime DeliveryTime
