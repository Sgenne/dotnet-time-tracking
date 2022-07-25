import ProjectPageComponent from "../components/projects/ProjectPageComponent"
import withAuthentication from "../higherOrderComponents/WithAuthentication"

const projects = () => {
    return <ProjectPageComponent />
}

export default withAuthentication(projects)