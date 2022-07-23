import withAuthentication from "../higherOrderComponents/WithAuthentication"

const tags = () => {
  return (
    <div>tags</div>
  )
}

export default withAuthentication(tags);