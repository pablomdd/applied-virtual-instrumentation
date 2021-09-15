from cuenta import Account

mi_cuenta = Account("Pablito Mix", 54321, 1000)
a2 = Account("Bid binny", 54300, 3500)

mi_cuenta.deposit(10000)
mi_cuenta.withdraw(5000)
mi_cuenta.dumb()
a2.withdraw(1500)
a2.deposit(500)
a2.dumb()
