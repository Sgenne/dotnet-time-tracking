import Modal from "../utils/Modal"
import styles from "../../styles/projects/NewProjectModal.module.css";
import TransparentCloseButton from "../utils/buttons/TransparentCloseButton";
import ClearTextInput from "../utils/input/ClearTextInput";
import TextArea from "../utils/input/TextArea";
import ControlledStateHandler from "../../types/ControlledStateHandler";
import PrimaryButton from "../utils/buttons/PrimaryButton";
import Validator from "../../types/Validator";

export interface NewProjectModalProps {
    nameStateHandler: ControlledStateHandler<string>;
    descriptionStateHandler: ControlledStateHandler<string>;
    nameValidator: Validator<string>;
    onClose: () => void;
    onSubmit: () => void;
}

const NewProjectModal = ({ nameStateHandler, descriptionStateHandler, onClose }: NewProjectModalProps) => {
    return (
        <Modal>
            <div className={styles["container"]}>
                <div className={styles["top-section"]}>
                    <h4>New Project</h4>
                    <TransparentCloseButton onClick={onClose} />
                </div>
                <div className={`${styles["name-section"]} ${styles["input-section"]}`}>
                    <div className={styles["label"]}>
                        <label>Name</label>
                    </div>
                    <div className={styles["name-input"]}>
                        <ClearTextInput
                            onChange={nameStateHandler.onChange}
                            value={nameStateHandler.value}
                            hasError={nameStateHandler.hasError}
                            onBlur={nameStateHandler.onBlur} />
                    </div>
                </div>
                <div className={`${styles["description-section"]} ${styles["input-section"]}`}>
                    <div className={styles["label"]}>
                        <label>Description</label>
                    </div>
                    <div className={styles["description-input"]}>
                        <TextArea
                            onChange={descriptionStateHandler.onChange}
                            value={descriptionStateHandler.value}
                            hasError={descriptionStateHandler.hasError}
                            onBlur={descriptionStateHandler.onBlur} />
                    </div>
                </div>
                <div className={styles["submit-button"]}>
                    <PrimaryButton onClick={() => { }}>Create Project</PrimaryButton>
                </div>
            </div>
        </Modal>
    )
}

export default NewProjectModal