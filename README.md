# The Bid Calculation

In this design, the FeeCalculator class takes an abstract factory (IFeeFactory) as a parameter.

Each concrete factory (CommonVehicleFeeFactory, LuxuryVehicleFeeFactory) is responsible for creating a family of related fee calculation strategies.

The abstract product interfaces (IBasicUserFeeStrategy, ISellersSpecialFeeStrategy, IAssociationAddedCostStrategy) define the behavior of the strategies.
The concrete product classes implement these interfaces.

This approach follows the Abstract Factory pattern and helps maintain a separation of concerns.