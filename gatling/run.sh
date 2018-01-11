SIMULATIONS_DIR=`dirname ${BASH_SOURCE[0]}`
  $GATLING_HOME/bin/gatling.sh \
  -sf $SIMULATIONS_DIR \
  -s gatling.simulations.LoadTest
