import { withDefaultLayout } from "../components/layouts/DefaultLayout";
import withAuthentication from "../higherOrderComponents/WithAuthentication"

const tags = () => {
  return (
    <div>tags</div>
  )
}

export default withAuthentication(withDefaultLayout(tags));