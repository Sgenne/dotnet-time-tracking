import styles from "../../styles/projects/SingleProjectPageComponent.module.css"
import Project from "../../types/domain/Project";
import PrimaryButton from "../utils/buttons/PrimaryButton";
import PlusIcon from "../utils/icons/PlusIcon";

export interface SingleProjectPageComponentProps {
    project: Project;
}

const SingleProjectPageComponent = ({ project }: SingleProjectPageComponentProps) => <div>
    <div className={styles["top-bar"]}>
        <h2>{project.title}</h2>
        <span className={styles["new-activity-button-container"]}>
            <PrimaryButton onClick={() => { }}><span className={styles["new-activity-button-content"]}>
                <PlusIcon />
                Add activity
            </span></PrimaryButton>
        </span>
    </div>
</div>


export default SingleProjectPageComponent