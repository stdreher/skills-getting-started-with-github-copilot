def add(a, b):
    return a + b

def subtract(a, b):
    return a - b

def multiply(a, b):
    return a * b

def divide(a, b):
    if b == 0:
        return "Fehler: Division durch Null nicht möglich"
    return a / b

print("=== Rechner ===")
print("1. Addition")
print("2. Subtraktion")
print("3. Multiplikation")
print("4. Division")

choice = input("Wähle eine Operation (1/2/3/4): ")

num1 = float(input("Erste Zahl: "))
num2 = float(input("Zweite Zahl: "))

if choice == "1":
    print(f"Ergebnis: {num1} + {num2} = {add(num1, num2)}")
elif choice == "2":
    print(f"Ergebnis: {num1} - {num2} = {subtract(num1, num2)}")
elif choice == "3":
    print(f"Ergebnis: {num1} × {num2} = {multiply(num1, num2)}")
elif choice == "4":
    result = divide(num1, num2)
    print(f"Ergebnis: {num1} ÷ {num2} = {result}")
else:
    print("Ungültige Auswahl!")
