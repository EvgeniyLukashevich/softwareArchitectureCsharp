## SOFTWARE ARCHITECTURE
### Seminar 10. Homework
##
#### Задание:
По возможности доработать наш WEB API сервис с использованием шаблона Repository. Добавить 1-2 контроллера, протянуть взаимодействие с БД как мы это выполнили на примере репозитория ClientRepository и контроллера ClientController.
##
###### Добавил контроллер для работы с животными (PetController) протянул взаимодействие c БД (используя IRepository, IPetRepository, PetRepository, CreatePetRequest, UpdatePetRequest) на основе модели Pet. 
###### На уровне IPetRepository добавил функцию получения списка животных по id клиента, реализовал её на уровне PetRepository и использовал в PetController