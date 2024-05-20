# Currency Converter API

This project implements a Currency Converter API using ASP.NET Core and the Frankfurter public API.

## Requirements

- Retrieve the latest exchange rates for a specific base currency.
- Convert amounts between different currencies, excluding TRY, PLN, THB, and MXN.
- Return historical rates for a given period using pagination based on a specific base currency.

## Running the Application

1. Clone the repository:
    ```bash
    git clone https://github.com/cengizhanvancin/CurrencyConverter
    cd currency-converter
    ```

2. Build and run the application:
    ```bash
    dotnet build
    dotnet run
    ```

3. The API will be available at `https://localhost:44307/swagger`.

## Endpoints

- `GET /exchangeRates/latest/{baseCurrency}`: Retrieve the latest exchange rates for a specific base currency.
- `GET /exchangeRates/convert?from={from}&to={to}&amount={amount}`: Convert amounts between different currencies.
- `GET /exchangeRates/historical?baseCurrency={baseCurrency}&startDate={startDate}&endDate={endDate}`: Retrieve historical exchange rates.

## Assumptions

- Only TRY, PLN, THB, and MXN are excluded from conversions.
- The Frankfurter API may require retries due to intermittent failures.

## Enhancements

- Implement caching to reduce the number of requests to the Frankfurter API.
- Add additional validation and error handling.
