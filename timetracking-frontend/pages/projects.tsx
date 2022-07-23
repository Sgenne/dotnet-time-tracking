import withAuthentication from "../higherOrderComponents/WithAuthentication"

const projects = () => {
    return (
        <div>projects</div>
    )
}

export default withAuthentication(projects)