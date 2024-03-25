# Calculators

Calculators have no direct connection to the hardware, but communicate exclusively with the signal hub.

The calculators are called up in special calculator tasks. A calculator task first calls the calculator assigned to it in  `read` mode. This gives the calculator the opportunity to read signals from the signal hub. Once the signals have been read, the calculator is called up in `calculate` mode. In the last step, the calculator is called up in `write` mode and can now write the calculated values back to the signal hub.

## Temperature monitoring

## Configuration

