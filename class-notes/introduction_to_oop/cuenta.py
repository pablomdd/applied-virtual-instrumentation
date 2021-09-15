class Account:
    def __init__(self, name, account_number, initial_amount) -> None:
        self.name = name
        self.no = account_number
        self.balance = initial_amount

    def deposit(self, amount):
        self.balance += amount

    def withdraw(self, amount):
        self.balance -= amount

    def dumb(self):
        s = self.name + ", " + str(self.no) + ", balance: " + str(self.balance)
        print(s)
