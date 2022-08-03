import { withDefaultLayout } from "../components/layouts/DefaultLayout";
import withAuthentication from "../higherOrderComponents/WithAuthentication"

const timer = () => {
  return (
    <div>timer</div>
  )
}

export default withAuthentication(withDefaultLayout(timer));