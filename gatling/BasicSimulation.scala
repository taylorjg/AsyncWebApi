package gatling.simulations

import io.gatling.core.Predef._
import io.gatling.http.Predef._
import scala.concurrent.duration._

class LoadTest extends Simulation {

  private val httpConf = http.baseURL("http://localhost:5000")

  val scn = scenario("BasicSimulation")
    .exec(http("GET /api/async")
    .get("/api/async"))

  setUp(
    scn.inject(rampUsers(400) over (10 seconds))
  ).protocols(httpConf)
}
